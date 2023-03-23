import { Navigate, Outlet, useLocation } from "react-router-dom"
import Role from "../../enums/role.enum"
import useAuth from "../../hooks/useAuth"
import { allPath } from "../../utilities/routes/routes.utility"

type RequireAuthProps = {
    allowedRoles: Role[]
}

const RequireAuth = ({allowedRoles}: RequireAuthProps) => {
    const { auth } = useAuth()
    const location = useLocation()

    if(!auth || !auth.user)
        return <Navigate to={allPath.login} state={{from: location}} replace/>

    const roles = auth?.user.roles
    if(allowedRoles.length != 0 && !roles.find(role => allowedRoles.includes(role)))
        return <Navigate to={allPath.unauthorized} state={{from: location}} replace />
    
    return <Outlet/>
}

export default RequireAuth