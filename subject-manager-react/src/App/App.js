import './App.css';
import { Book } from 'react-bootstrap-icons';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import LoginPage from '../LoginPage/LoginPage';
import HomePage from '../HomePage/HomePage';
import RegisterPage from '../RegisterPage/RegisterPage';
import AllSubjectsPage from '../AllSubjectsPage/AllSubjectsPage';
import SubjectAddPage from '../AllSubjectsPage/SubjectAddPage/SubjectAddPage';
function App() {



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
            <Route path={'/login'} element={<LoginPage />} />
            <Route path={'/register'} element={<RegisterPage />} />
            <Route path={'/home'} element={localStorage.getItem("token") ? <HomePage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects'} element={localStorage.getItem("token") ? <AllSubjectsPage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/add'} element={localStorage.getItem("token") ? <SubjectAddPage /> : <Navigate to={'/login'} />} />
          </Routes>
        </div>
      </Router>
    </div>
  );


}

export default App;
