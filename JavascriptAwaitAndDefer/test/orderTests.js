"use strict";
require('tamejs').register();
require('coffee-script');
require('iced-coffee-script');
require('streamline').register({
    fibers: false,
    cache: true,
    verbose: true
});

function addTest(file) {
    module.exports[file] = require(file);
}

/*
 addTest('./1_orderPyramidOfDoom.js');
 addTest('./1_orderPyramidOfDoom.coffee');
 addTest('./2_orderTameJS.tjs');
 addTest('./2_orderIcedCoffeeScript.iced');
 addTest('./3a_orderStep.coffee');
 addTest('./3b_orderInvoke.coffee');
 addTest('./3c_orderNue.coffee');
 addTest('./3d_orderAsyncjs.coffee');
 addTest('./4_orderQ.coffee');
 addTest('./5_orderStreamline._coffee');
 */
addTest('./5_orderStreamline._js');
