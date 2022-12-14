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
import TestAddPage from '../TestAddPage/TestAddPage';
import TestViewPage from '../TestViewPage/TestViewPage';
import TestUpdatePage from '../TestUpdatePage/TestUpdatePage';
import MaterialAddPage from '../MaterialAddPage/MaterialAddPage';
import MaterialViewPage from '../MaterialViewPage/MaterialViewPage';
import MaterialUpdatePage from '../MaterialUpdatePage/MaterialUpdatePage';

export const url = "https://localhost:7158";

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
            <Route path={'/subjects/:id/update'} element={localStorage.getItem("token") ? <SubjectUpdatePage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/:id/view'} element={localStorage.getItem("token") ? <SubjectViewPage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/:id/tests/add'} element={localStorage.getItem("token") ? <TestAddPage /> : <Navigate to={'/login'} />} />
            <Route path={'/tests'} element={localStorage.getItem("token") ? <AllTestsPage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/:sid/tests/:tid/view'} element={localStorage.getItem("token") ? <TestViewPage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/:sid/tests/:tid/update'} element={localStorage.getItem("token") ? <TestUpdatePage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/:id/materials/add'} element={localStorage.getItem("token") ? <MaterialAddPage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/:sid/materials/:lid/view'} element={localStorage.getItem("token") ? <MaterialViewPage /> : <Navigate to={'/login'} />} />
            <Route path={'/subjects/:sid/materials/:lid/update'} element={localStorage.getItem("token") ? <MaterialUpdatePage /> : <Navigate to={'/login'} />} />
          </Routes>
        </div>
      </Router>
    </div>
  );


}

export default App;
