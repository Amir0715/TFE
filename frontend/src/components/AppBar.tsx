import { AppBar, IconButton, Toolbar, Typography } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import SearchInput from "./SearchInput";
import ProfileName from "./ProfileName";

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
                boxShadow: 'none',
                backgroundColor: 'inherit',
            }}
        >
            <Toolbar
                sx={{
                    justifyContent: "space-between",
                }}
            >
                {/* <IconButton
                    aria-label="open drawer"
                    edge="start"
                    onClick={handleDrawerToggle}
                    sx={{ mr: 2, display: { sm: 'none' }, color: "black" }}
                >
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" noWrap component="div" sx={{ color: "black" }}>
                    {title}
                </Typography> */}
                <SearchInput />
                <ProfileName />
            </Toolbar>
        </AppBar>
    );
};

export { MyAppBar as AppBar };
