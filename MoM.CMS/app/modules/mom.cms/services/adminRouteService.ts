/// <reference path="../../../../../../node_modules/reflect-metadata/reflect-metadata.d.ts"/>
import {Injectable, Type, ViewEncapsulation} from 'angular2/core'
import {RouteRegistry} from 'angular2/router'
import {AdminTest} from '../pages/admintest'

@Injectable()
export class AdminDynamicRouteConfigurator {
    constructor(private registry: RouteRegistry) { }

    addRoute(component: Type, route) {
        let routeConfig = this.getRoutes(component);
        routeConfig.configs.push(route);
        this._updateRouteConfig(component, routeConfig);
        this.registry.config(component, route);
    }
    getRoutes(component: Type) {
        return Reflect.getMetadata('annotations', component)
            .filter(a => {
                return a.configs != undefined;
            }).pop();
    }
    _updateRouteConfig(component: Type, routeConfig) {
        let annotations = Reflect.getMetadata('annotations', component);
        let routeConfigIndex = -1;
        for (let i = 0; i < annotations.length; i += 1) {
            if (annotations[i].configs != undefined) {
                routeConfigIndex = i;
                break;
            }
        }
        if (routeConfigIndex < 0) {
            throw new Error('No route metadata attached to the component');
        }
        annotations[routeConfigIndex] = routeConfig;
        Reflect.defineMetadata('annotations', annotations, AdminTest);
    }
} 