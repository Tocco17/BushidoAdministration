import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { AuthProvider } from '../contextes/auth.context';
import { RouteInterface } from '../utilities/routes.utility';
import everyCompleteRoutes, { CompleteRouteListInterface, privateNoRoleRoutes, PrivateRouteListInterface, publicRoutes } from '../utilities/routing.utility';
import RequireAuth from './auth/require-auth';


const RouteComponent = () => {
    const mapRoutes = (routes: RouteInterface[]) => 
        routes.map((r) => (<Route path={r.path} element={r.element} key={r.path} />))

    const mapPrivateRoutes = (routeList: PrivateRouteListInterface) => (
        <Route element={<RequireAuth allowedRoles={routeList.allowedRoles}/>}>
            { mapRoutes(routeList.routes) }
        </Route>
    )

    const mapCompleteRoutes = (completeRoute: CompleteRouteListInterface) => (
        <Route path={completeRoute.path} element={completeRoute.element}>
            { mapRoutes(completeRoute.publicRoutes.routes) }

            { completeRoute.privateRoutes.map(mapPrivateRoutes)}
        </Route>
    )

    return (
        <>
        <AuthProvider>
            <BrowserRouter>
                <Routes>
                    { everyCompleteRoutes.map(mapCompleteRoutes) }
                </Routes>
            </BrowserRouter>
        </AuthProvider>
        </>
    )
}

export default RouteComponent