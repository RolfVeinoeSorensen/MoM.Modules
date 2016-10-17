/**
 * System configuration for MoM Angular 2
 * Adjust as necessary for your application needs.
 */
(function(global) {
  // map tells the System loader where to look for things
  var map = {
    'app':                          'app', // 'dist',
    '@angular':                     'lib/@angular',
    //'angular2-in-memory-web-api':   'lib/angular2-in-memory-web-api',
    'rxjs':                         'lib/rxjs',
    'moment':                       'lib/moment.min.js',
    //'ng2-bootstrap':                'lib/extensions/ng2-bootstrap',
    'ng2-prism':                    'lib/extensions/ng2-prism',
    'prismjs':                      'lib/extensions/ng2-prism/node_modules/prismjs',
    'dragula':                      'lib/extensions/dragula/dragula.js',
    'ng2-dragula':                  'lib/extensions/ng2-dragula/ng2-dragula.js'
  };
  // packages tells the System loader how to load when no filename and/or no extension
  var packages = {
    'app':                          { main: 'modules/MoM.Setup/install.js',  defaultExtension: 'js' },
    'rxjs':                         { defaultExtension: 'js' },
    'ng2-dragula':                  { defaultExtension: 'js' },
    //'angular2-in-memory-web-api': { defaultExtension: 'js' },
  };
  var ngPackageNames = [
     'common',
     'compiler',
     'core',
     'forms',
     'http',
     'platform-browser',
     'platform-browser-dynamic',
     'router'
  ];
    // Add package entries for angular packages
    // Individual files (~300 requests):
  function packIndex(pkgName) {
      packages['@angular/' + pkgName] = { main: 'index.js', defaultExtension: 'js' };
  }
    // Bundled (~40 requests):
  function packUmd(pkgName) {
      packages['@angular/' + pkgName] = { main: '/bundles/' + pkgName + '.umd.js', defaultExtension: 'js' };
  }
    // Most environments should use UMD; some (Karma) need the individual index files
  var setPackageConfig = System.packageWithIndex ? packIndex : packUmd;
    // Add package entries for angular packages
  ngPackageNames.forEach(setPackageConfig);
  var config = {
      map: map,
      packages: packages
  };
  System.config(config);
})(this);