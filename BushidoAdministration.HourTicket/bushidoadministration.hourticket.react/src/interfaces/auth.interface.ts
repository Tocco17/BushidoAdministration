import Role from "../enums/role.enum"
import User from "./User"

interface AuthInterface {
    user: User | undefined
}

export default AuthInterface