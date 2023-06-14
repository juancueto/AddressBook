import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';

import { AddressBookApp } from './AddressBookApp';
import './main.css'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <AddressBookApp />
    </BrowserRouter>
  </React.StrictMode>,
)
