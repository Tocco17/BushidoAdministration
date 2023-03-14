export const writeStorage = (key: string, object: any) => localStorage.setItem(key, JSON.stringify(object))

export const readStorage = (key: string) => JSON.parse(localStorage.getItem(key) as string)

export const removeStorage = (key: string) => localStorage.removeItem(key)