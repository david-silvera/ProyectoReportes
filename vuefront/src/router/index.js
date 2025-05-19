import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '@/views/LoginView.vue'
import VistaPrincipal from '@/views/VistaPrincipal.vue'
import DetalleIncidenteView from '@/views/DetalleIncidenteView.vue'
import MisNoticiasView from '@/views/MisNoticiasView.vue'
import CrearNoticiaView from '@/views/CrearNoticiaView.vue'


const routes = [
  {
    path: '/',
    name: 'loginview',
    component: LoginView
  },
  {
    path: '/vistaprincipal',
    name: 'vistaprincipal',
    component: VistaPrincipal,
    props: true

  },
  {
  path: '/detalleincidente',
  name: 'DetalleIncidente',
  component: DetalleIncidenteView
},
 {
  path: '/misnoticias',
  name: 'misnoticias',
  component: MisNoticiasView
},
{
  path: '/crearnoticia',
  name: 'crearnoticia',
  component: CrearNoticiaView
},
{
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
