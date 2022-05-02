import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";
import CssBaseline from '@mui/material/CssBaseline';
import MainPage from "./pages/MainPage";
// import TestPage from "./pages/TestPage";

const App = () => {
  return (
    <div className="App">
      <BrowserRouter basename='/' >
        <CssBaseline />
        <Routes>
          <Route path="*" element={<MainPage />} />
          {/* <Route path="/login" element={<LoginPage />} /> */}
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App;
