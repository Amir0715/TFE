import { AppBar, IconButton, Toolbar, Typography } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";

interface AppBarProps {
    drawerWidth: number,
    handleDrawerToggle: any,
    title: string,
}

const MyAppBar = ({ drawerWidth, handleDrawerToggle, title }: AppBarProps) => {
    return (
        <AppBar
            position="fixed"
            sx={{
                width: { sm: `calc(100% - ${drawerWidth}px)` },
                ml: { sm: `${drawerWidth}px` },
                backgroundColor: 'white',
            }}
        >
            <Toolbar>
                <IconButton
                    aria-label="open drawer"
                    edge="start"
                    onClick={handleDrawerToggle}
                    sx={{ mr: 2, display: { sm: 'none' }, color: "black" }}
                >
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" noWrap component="div" sx={{ color: "black" }}>
                    {title}
                </Typography>
            </Toolbar>
        </AppBar>
    );
};

export { MyAppBar as AppBar };
