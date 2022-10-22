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
import SubjectUpdatePage from '../AllSubjectsPage/SubjectUpdatePage/SubjectUpdatePage';
import SubjectViewPage from '../AllSubjectsPage/SubjectViewPage/SubjectViewPage';
import AllTestsPage from '../AllTestsPage/AllTestsPage';
function App() {



  return (
    <div className='App'>
      <div className='header glass-bg'>

        <div className='title'>
          <div className='title-icon'><Book /></div>
          <div className='title-text demoFont'>Subject Manager</div>

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
            <Route path={'/subjects/update/:id'} element={localStorage.getItem("token") ? <SubjectUpdatePage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/view/:id'} element={localStorage.getItem("token") ? <SubjectViewPage /> : <Navigate to={'/login'} />} />
            <Route path={'/tests'} element={localStorage.getItem("token") ? <AllTestsPage /> : <Navigate to={'/login'} />} />
          </Routes>
        </div>
      </Router>
    </div>
  );


}

export default App;
