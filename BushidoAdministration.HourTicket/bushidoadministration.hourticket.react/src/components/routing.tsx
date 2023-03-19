import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { publicRoutes, RouteInterface } from '../utilities/routing.utility';


const RouteComponent = () => {
    const mapRoutes = (routes: RouteInterface[]) => 
        routes.map((r) => (<Route path={r.path} element={r.element} key={r.path} />))

    return (
        <>
        <BrowserRouter>
            <Routes>
                <Route path='/' >
                    { mapRoutes(publicRoutes.routes) }
                </Route>
            </Routes>
        </BrowserRouter>
        </>
    )
}

export default RouteComponent