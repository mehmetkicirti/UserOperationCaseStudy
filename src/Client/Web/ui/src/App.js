import {
  BrowserRouter,
  Route,
  Routes
} from 'react-router-dom';
import {createBrowserHistory} from "history";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import MainLayout from './layouts/MainLayout';
import Home from "./pages/Home";
import NotFound from './pages/NotFound';
import UpdateUser from './pages/UpdateUser';

function App() {
  const browserHistory = createBrowserHistory();
  return (
    <BrowserRouter history={browserHistory}>
      <div>
        <ToastContainer/>
        <Routes>
              <Route path="/*" element={<MainLayout><Home/></MainLayout>}/>
              <Route path="/users/:id/*" element={<MainLayout><UpdateUser/></MainLayout>}/>
              <Route element={<NotFound errorValue={"There is an error"}/>}/>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
