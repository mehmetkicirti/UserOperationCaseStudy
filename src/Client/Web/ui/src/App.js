import {
  BrowserRouter as Router,
  Route,
  browserHistory,
  Switch
} from 'react-router-dom';
import { ToastContainer } from "react-toastify";
import Home from "./pages/Home";
import NotFound from './pages/NotFound';

function App() {
  return (
    <Router history={browserHistory}>
      <div>
        <ToastContainer/>
        <Switch>
            <Route exact path="/" element={Home}/>
            <Route element={NotFound}/>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
