import Role from "../enums/role.enum"

interface AuthInterface {
    roles: Role[],
    accessToken: string,
    user: any
}

export default AuthInterface