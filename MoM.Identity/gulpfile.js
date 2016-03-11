/// <binding AfterBuild='copy-module' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

var paths = {
    modulepath: "../artifacts/bin/MoM.Identity/Debug/dnxcore50/",
    moduleDestination: "../../MoM/artifacts/bin/Modules"
}

gulp.task('copy-module', function () {
    gulp.src([
                paths.modulepath + "MoM.Identity.dll",
                paths.modulepath + "MoM.Identity.pdb"
    ])
    .pipe(gulp.dest(paths.moduleDestination));
});