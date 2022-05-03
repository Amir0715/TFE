import { useState } from "react";
import { Route, Routes } from "react-router-dom";
import { Box, Toolbar } from "@mui/material";
import AllTestPage from "../pages/AllTestsPage";
import CategoriesPage from "../pages/CategoriesPage";
import { NavBar } from "../components/NavBar";
import { AppBar } from "../components/AppBar";
import HomePage from "./HomePage";

const drawerWidth = 250; // px

interface MainPageProps {
    window?: any,
}

// Главная страница, она будет содержать роутеры, аппбар и навбар, внутри нее будет находиться остальные страницы
const MainPage = ({ window }: MainPageProps) => {
    const [mobileOpen, setMobileOpen] = useState(false);

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    const container = window !== undefined ? () => window().document.body : undefined;

    return (
        <Box sx={{ display: 'flex', backgroundColor: "#F6F8FB" }}>
            <AppBar drawerWidth={drawerWidth} handleDrawerToggle={handleDrawerToggle} title="Главная страница" />
            <NavBar drawerWidth={drawerWidth} />
            <Box component="main" sx={{ flexGrow: 1, p: 3, height: "100vh" }}>
                <Toolbar />
                <Routes>
                    <Route path='/' element={<HomePage />} />
                    <Route path='/tests/all' element={<AllTestPage />} />
                    <Route path='/tests/categories' element={<CategoriesPage />} />
                </Routes>
            </Box>
        </Box>
    )
}

export default MainPage;
