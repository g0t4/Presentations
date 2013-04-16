"use strict";
require('coffee-script');

function addTest(file) {
    module.exports[file] = require(file);
}

/*
 addTest('./1_orderPyramidOfDoom.js');
 addTest('./1_orderPyramidOfDoom.coffee');

 require('tamejs').register();
 addTest('./2_orderTameJS.tjs');

 require('iced-coffee-script');
 addTest('./2_orderIcedCoffeeScript.iced');

 addTest('./3a_orderStep.coffee');
 addTest('./3b_orderInvoke.coffee');
 addTest('./3c_orderNue.coffee');
 addTest('./3d_orderAsyncjs.coffee');

 require('streamline').register({
 fibers: false,
 cache: true,
 verbose: true
 });
 addTest('./5_orderStreamline._coffee');
 addTest('./5_orderStreamline._js');
 */
addTest('./4_orderQ.coffee');

