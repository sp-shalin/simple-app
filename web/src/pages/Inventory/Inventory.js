import React, { Component } from 'react';
import CreateInventory from './CreateInventory';
import { Link } from "react-router-dom";
import useToken from './core/useToken';

async function _getInventory() {
    const { token } = useToken();

    return fetch('https://localhost:7133/api/inventory/get', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer '+ token,

        }
    })
        .then(data => data.json())
}

class Inventory extends Component {
    _addInventory() {
        return (
            <CreateInventory />
        );
    }

    _allInventory () {
        return (
            <div>
                <h3>All Inventory</h3>
                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Price</th>
                            <th>Quantity</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Item 1</td>
                            <td>Description 1</td>
                            <td>$1.00</td>
                            <td>1</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }

    render() {
        return (
            <div>
                <h1>Inventory</h1>
                <Link to="/add">Add Inventory</Link>

                {this._allInventory()}
            </div>
        )
    }
};

export default Inventory;