from flask import Blueprint, request, jsonify
from . import mysql

main = Blueprint('main', __name__)

@main.route('/save_player', methods=['POST'])
def save_player():
    data = request.json

    player_name = data['name']
    inventory = data['inventory']
    status = data['status']
    status_effect = data['statusEffect']

    cursor = mysql.connection.cursor()

    # Save player
    cursor.execute("INSERT INTO Player (player_name) VALUES (%s) ON DUPLICATE KEY UPDATE player_name=VALUES(player_name)", (player_name,))
    mysql.connection.commit()

    cursor.execute("SELECT player_id FROM Player WHERE player_name = %s", (player_name,))
    player_id = cursor.fetchone()[0]

    # Save inventory
    for item_name, quantity in inventory.items():
        cursor.execute("SELECT item_id FROM Item WHERE item_name = %s", (item_name,))
        item_id = cursor.fetchone()[0]
        cursor.execute("""
            INSERT INTO PlayerInventory (player_id, player_inventory_item_id, player_inventory_item_name, player_inventory_item_quantity)
            VALUES (%s, %s, %s, %s) ON DUPLICATE KEY UPDATE player_inventory_item_quantity=VALUES(player_inventory_item_quantity)
        """, (player_id, item_id, item_name, quantity))
        mysql.connection.commit()

    # Save status
    for status_name, value in status.items():
        cursor.execute("""
            INSERT INTO PlayerStatus (player_id, player_status_name, player_status_value)
            VALUES (%s, %s, %s) ON DUPLICATE KEY UPDATE player_status_value=VALUES(player_status_value)
        """, (player_id, status_name, value))
        mysql.connection.commit()

    # Save status effects
    for status_effect_name, value in status_effect.items():
        cursor.execute("""
            INSERT INTO PlayerStatusEffect (player_id, player_status_effect_name, player_status_effect_value)
            VALUES (%s, %s, %s) ON DUPLICATE KEY UPDATE player_status_effect_value=VALUES(player_status_effect_value)
        """, (player_id, status_effect_name, value))
        mysql.connection.commit()

    return jsonify({"status": "success"})

@main.route('/get_player', methods=['GET'])
def get_player():
    player_name = request.args.get('name')

    cursor = mysql.connection.cursor()

    cursor.execute("SELECT player_id FROM Player WHERE player_name = %s", (player_name,))
    player_id = cursor.fetchone()[0]

    cursor.execute("SELECT item_name, player_inventory_item_quantity FROM PlayerInventory JOIN Item ON PlayerInventory.player_inventory_item_id = Item.item_id WHERE player_id = %s", (player_id,))
    inventory = {item_name: quantity for item_name, quantity in cursor.fetchall()}

    cursor.execute("SELECT player_status_name, player_status_value FROM PlayerStatus WHERE player_id = %s", (player_id,))
    status = {status_name: value for status_name, value in cursor.fetchall()}

    cursor.execute("SELECT player_status_effect_name, player_status_effect_value FROM PlayerStatusEffect WHERE player_id = %s", (player_id,))
    status_effect = {status_effect_name: value for status_effect_name, value in cursor.fetchall()}

    player_data = {
        "name": player_name,
        "inventory": inventory,
        "status": status,
        "statusEffect": status_effect
    }

    return jsonify(player_data)
