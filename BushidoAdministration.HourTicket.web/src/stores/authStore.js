import { defineStore } from 'pinia'
import router from '../plugins/router'

export const useAuthStore = defineStore('auth', {
    state: () => {
        return {
            _isLogged: false
        }
    },
    actions: {
        login(username, password, inLocalStorage) {
            if (inLocalStorage)
                localStorage.setItem('auth', { username, password })

            return new Promise((resolve, reject) => {
                this._isLogged = true;
                resolve(true);
            });
        },
        logout() {
            this._isLogged = false;
            localStorage.clear();
            router.push('/login');
        }
    },
    getters: {
        isLogged() {
            return this._isLogged || !!localStorage.getItem('auth')
        }
    }
})