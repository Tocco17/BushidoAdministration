import { createRouter, createWebHistory } from 'vue-router';

const home = {template: '<div>Home</div>'}

const routes = [
    { path: '/', component: home},
]

const router = createRouter({
    history: createWebHistory,
    routes
})

export default router