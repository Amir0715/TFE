import React from 'react'
import { AppBar, Box, IconButton, Toolbar, Typography } from "@mui/material";
import TimerLine from './TimerLine';

const TestPageAppBar = () => {
    return (
        <Box>
            <AppBar
                position="static"
                sx={{
                    // width: { sm: `calc(100% - ${drawerWidth}px)` },
                    // ml: { sm: `${drawerWidth}px` },
                    // boxShadow: 'none',
                    // backgroundColor: '',
                }}
            >
                <Typography variant="h4" sx={{ color: "black" }} align="center" m={1}>Название теста</Typography>
                <TimerLine max={100} min={0} value={50} />
            </AppBar>
        </Box>
    )
}

export default TestPageAppBar
