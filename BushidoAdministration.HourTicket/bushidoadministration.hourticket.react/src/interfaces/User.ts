import Base from "./Base";
import Role from "./Role";

interface User extends Base {
    email: string
    password: string
    roles: Role[]
}

export default User