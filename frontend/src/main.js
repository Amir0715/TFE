import { createApp } from 'vue'
import App from './App.vue'
import { VuesticPlugin } from 'vuestic-ui' // <-
import 'vuestic-ui/dist/vuestic-ui.css' // <-
import Vuex from 'vuex'
import router from './router'

const app = createApp(App)
app.use(VuesticPlugin)
app.use(Vuex)
app.use(router)
app.mount('#app')