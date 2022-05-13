import React, { Component } from 'react'

class CreateInventory extends Component {
    _addInventory() {
        return (
            <div>
                <h1>Add Inventory</h1>
                <form>
                    <label>
                        <p>Name</p>
                        <input type="text" />
                    </label>
                    <label>
                        <p>Description</p>
                        <input type="text" />
                    </label>
                    <label>
                        <p>Price</p>
                        <input type="text" />
                    </label>
                    <label>
                        <p>Quantity</p>
                        <input type="text" />
                    </label>
                    <button type="submit">Submit</button>
                </form>
            </div>
        );
    }

    render() {
        return (
        <div>
            {this._addInventory()}
        </div>
        )
    }
};

export default CreateInventory;