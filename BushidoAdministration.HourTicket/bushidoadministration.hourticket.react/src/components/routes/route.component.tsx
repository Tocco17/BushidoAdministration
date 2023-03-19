import { Route, Routes } from 'react-router-dom';
import PersistLogin from '../auth/persist-login';
import { PrivateRouteListInterface, privateRoutes, publicRoutes, RouteInterface, RouteListInterface } from '../../utilities/routes';
import AuthLayout from '../layouts/auth.layout';
import RequireAuth from '../auth/require-auth.component';

const RouteComponent = () => {
    const mapRoutes = (routes: RouteInterface[]) => 
        routes.map((r) => (<Route path={r.path} element={r.element} key={r.path} />))

    const mapPrivateRoutes = (routeList: PrivateRouteListInterface) => (
        <Route element={<RequireAuth allowedRoles={routeList.allowedRoles}/>}>
            { mapRoutes(routeList.routes) }
        </Route>
    )

    return (
        <>
        <Routes>
            <Route path='/' element={<AuthLayout />}>
                { mapRoutes(publicRoutes.routes) }

                { mapPrivateRoutes(privateRoutes) }
            </Route>
        </Routes>
        </>
    )
}

export default RouteComponent