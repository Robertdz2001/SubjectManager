import './App.css';
import { Book } from 'react-bootstrap-icons';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import LoginPage from '../LoginPage/LoginPage';
import { PlusCircle } from 'react-bootstrap-icons';
import { useState } from 'react';
import HomePage from '../HomePage/HomePage';
function App() {

  const [token, setToken] = useState("");

  function changeToken(newToken) {
    setToken(newToken);
  }

  return (
    <div className='App'>
      <div className='header'>

        <div className='title'>
          <div className='title-icon'><Book /></div>
          <div className='title-text'>Subject Manager</div>

        </div>

      </div>
      <Router>
        <div className='Routes'>
          <Routes>
            <Route path={'/'} element={<Navigate to={'/login'} />} />
            <Route path={'/login'} element={<LoginPage changeToken={changeToken} />} />
            <Route path={'/home'} element={<HomePage token={token} />} />
          </Routes>
        </div>
      </Router>
    </div>
  );


}

export default App;
