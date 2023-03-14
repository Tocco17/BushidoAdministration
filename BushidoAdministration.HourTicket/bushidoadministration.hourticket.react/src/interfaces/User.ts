import Roles from "../enums/roles.enum";
import Base from "./Base";

interface User extends Base {
    email: string
    password: string
    roles: Roles[]
}

export default User