
//this calls the Vue.js 'component' method and mounts our header onto the page
Vue.component('header-component', {
    props: ['menuItems'],
    template: '<header><ul><li v-for="item in menuItems">{{ item }}</li></ul></header>'
});        /*"v-for" is the vuejs syntax for a 'foreach' loop */



//imporant note, when referencing a property, Newtonsoft will change it to camelcase.
//if you did "MenuItems" instead of 'menuItems', it would not be able to key off of the json object