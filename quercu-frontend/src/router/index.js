import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/property",
    name: "Property",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "property" */ "../views/property/Property.vue"),
  },
  {
    path: "/property/add",
    name: "AddProperty",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "property" */ "../views/property/AddProperty.vue"),
  },
  {
    path: "/property/update/:id",
    name: "UpdateProperty",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "property" */ "../views/property/UpdateProperty.vue"),
  },
  {
    path: "/property-type",
    name: "PropertyType",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "property-type" */ "../views/type/PropertyType.vue"),
  },
  {
    path: "/property-type/add",
    name: "AddPropertyType",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "property-type" */ "../views/type/AddPropertyType.vue"),
  },
  {
    path: "/property-type/update/:id",
    name: "UpdatePropertyType",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "property-type" */ "../views/type/UpdatePropertyType.vue"),
  },
  {
    path: "/owner",
    name: "Owner",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "owners" */ "../views/owner/Owner.vue"),
  },
  {
    path: "/owner/add",
    name: "AddOwner",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "owners" */ "../views/owner/AddOwner.vue"),
  },
  
  {
    path: "/owner/update/:id",
    name: "UpdateOwner",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "owners" */ "../views/owner/UpdateOwner.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
