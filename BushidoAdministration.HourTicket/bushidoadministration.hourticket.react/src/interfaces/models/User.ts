import Role from "../../enums/role.enum";
import Base from "./Base";

interface User extends Base {
    email: string
    password: string
    roles: Role[]
}

export default User