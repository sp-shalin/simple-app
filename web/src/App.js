import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login/Login';
import Inventory from './pages/Inventory/Inventory';
import CreateInventory from './pages/Inventory/CreateInventory';
import useToken from './core/useToken';

function App() {
  const { token, setToken } = useToken();

  if(!token) {
    return <Login setToken={setToken} />
  }

  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={ <Inventory/> } />
          <Route path="/add" element={ <CreateInventory/> } />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
