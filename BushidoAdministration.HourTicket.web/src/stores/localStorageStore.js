import { defineStore } from 'pinia'

export const useLocalStorageStore = defineStore('localStorage', {
    actions: {
        read(key) {
            return localStorage.getItem(key);
        },
        write(toBeSaved) {
            for (key in toBeSaved) {
                this.write(key, toBeSaved[key])
            }
        },
        write(key, value) {
            localStorage.setItem(key, value)
        },
        isStored(key) {
            return !!this.read(key)
        },
    }
})