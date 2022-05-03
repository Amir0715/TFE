import { Divider, ListItemButton, ListItemText, Toolbar, Box } from "@mui/material";
import { Link } from "react-router-dom";
import { routesStructure } from "../routes";


// Список элементов в панели меню
const ListItems = () => {
    return (
        <div>
            {routesStructure.map(({ title, to }, index) => (
                <Box
                    key={index}
                    sx={{
                        display: "flex",
                        p: 1,
                    }}
                >
                    <ListItemButton
                        component={Link}
                        to={to}
                    >
                        <ListItemText primary={title} />
                    </ListItemButton>
                </Box>
            ))}
        </div>
    );
};

export { ListItems as NavBarListItem };
