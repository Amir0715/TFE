import { Box, Drawer, Toolbar } from "@mui/material";
import { NavBarListItem } from "./NavBarListItem";

interface NavBarProps {
    drawerWidth: number,
    container?: any,
    mobileOpen?: boolean,
    handleDrawerToggle?: any
}

const MyNavBar = ({ drawerWidth, container, mobileOpen, handleDrawerToggle }: NavBarProps) => {
    return (
        <Box
            component="nav"
            sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 0 }, boxShadow: "4px 0px 16px rgba(16, 30, 115, 0.08)", zIndex: 1299}}
            aria-label="mailbox folders"
        >
            {/* <Drawer
                container={container}
                variant="temporary"
                open={mobileOpen}
                onClose={handleDrawerToggle}
                ModalProps={{
                    keepMounted: true, // Better open performance on mobile.
                }}
                sx={{
                    display: { xs: 'block', sm: 'none' },
                    '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
                }}
            >
                <NavBarListItem />
            </Drawer> */}
            <Drawer
                variant="permanent"
                sx={{
                    display: { xs: 'none', sm: 'block' },
                    '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth, borderRight: "none" },
                }}
                open
                >
                <Toolbar>
                    Тестовая система
                </Toolbar>
                <NavBarListItem />
            </Drawer>
        </Box>
    );
};

export { MyNavBar as NavBar };
