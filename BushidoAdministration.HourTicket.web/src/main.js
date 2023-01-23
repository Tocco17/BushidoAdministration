import { createApp } from 'vue'
// import './style.css'
import './input.css'
import App from './App.vue'
import router from './plugins/router'


const app = createApp(App)

app.use(router)

app.mount('#app')