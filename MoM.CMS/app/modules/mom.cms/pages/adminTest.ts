import {AdminDynamicRouteConfigurator} from "../services/adminrouteservice";
export class AdminTest {
    appRoutes: any[];
    constructor(private dynamicRouteConfigurator: AdminDynamicRouteConfigurator) {
        this.appRoutes = this.getAppRoutes();
        let routes = [{ path: '/', component: "Home", name: 'Dashboard' },
            { path: '/order', component: "Order", name: 'Order' }];
        var i = -1;
        while (++i < routes.length) {
            this.dynamicRouteConfigurator.addRoute(this.constructor, routes[i]);
        }
        this.appRoutes = this.getAppRoutes();
    }

    private getAppRoutes(): any[] {
        return this.dynamicRouteConfigurator
            .getRoutes(this.constructor).configs.map(route => {
                return { link: [`/${route.name}`], title: route.name, icon: 'mdi-action-dashboard' };
            });
    }
}