import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { AuthProvider } from '../contextes/auth.context';
import { privateNoRoleRoutes, PrivateRouteListInterface, publicRoutes, RouteInterface } from '../utilities/routing.utility';
import RequireAuth from './auth/require-auth';


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
        <AuthProvider>
            <BrowserRouter>
                <Routes>
                    <Route path='/' >
                        { mapRoutes(publicRoutes.routes) }

                        { mapPrivateRoutes(privateNoRoleRoutes) }
                    </Route>
                </Routes>
            </BrowserRouter>
        </AuthProvider>
        </>
    )
}

export default RouteComponent