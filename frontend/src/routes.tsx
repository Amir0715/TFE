import { Route } from "react-router-dom";
import AllTestsPage from "./pages/AllTestsPage";
import CategoriesPage from "./pages/CategoriesPage";
// import DashboardPage from "../pages/DashboardPage";
// import OrdersPage from "../pages/OrdersPage";
// import CategoriesPage from "../pages/CategoriesPage";
// import ProductsPage from "../pages/ProductsPage";
// import UsersPage from "../pages/UsersPage";
// import StatisticsPage from "../pages/StatisticsPage";
// import SettingsPage from "../pages/SettingsPage";
// import ProductPage from "../pages/ProductPage";


const routesStructure = [
    { title: "Главная", to: "/", element: <AllTestsPage /> },
    { title: "Все тесты", to: "/tests/all", element: <AllTestsPage /> },
    { title: "Категории", to: "/tests/categories", element: <CategoriesPage /> },
    // { title: "Продукты", to: "/products", element: ProductsPage },
    // { title: "Продукт", to: "/product", element: ProductPage },
    // { title: "Пользователи", to: "/users", element: UsersPage},
    // { title: "Статистика", to: "/statistics", element: StatisticsPage },
    // { title: "Настройки", to: "/settings", element: SettingsPage },
    // { title: "Профиль", to: "/profile", element: SettingsPage },
];

const RoutersMap = () => {
    const data = routesStructure.map(({ title, to, element }, key) => <Route path={to} element={element} key={key} />);
    console.log(data);
    return data;
};

export default RoutersMap;
export { routesStructure };
