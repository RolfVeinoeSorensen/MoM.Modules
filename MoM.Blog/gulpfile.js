/// <binding AfterBuild='copy-module' ProjectOpened='watch-blog' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

"use strict";

var gulp = require("gulp"),
    runSequence = require("run-sequence"),
    tslint = require("gulp-tslint"),
    typescript = require('gulp-typescript'),
    sass = require('gulp-ruby-sass'),
    notify = require("gulp-notify"),
    bower = require('gulp-bower'),
    rimraf = require('rimraf'),
    uglify = require('gulp-uglify'),
    cssmin = require('gulp-cssmin'),
    rename = require('gulp-rename'),
    webpack = require('gulp-webpack');

var tsProject = typescript.createProject('app/tsconfig.json');

var moduleName = "MoM.Blog";

var paths = {
    modulepath: "bin/Debug/netcoreapp1.0/",
    moduleDestination: "../../MoM/artifacts/bin/Modules",
    scripDist: "./dist",
    scriptDestination: "../../MoM/MoM.Web/wwwroot/app/modules/" + moduleName
}

gulp.task('copy-module', function () {
    gulp.src([
                paths.modulepath + moduleName + ".dll",
                paths.modulepath + moduleName + ".pdb"
    ])
    .pipe(gulp.dest(paths.moduleDestination));
});

gulp.task('copy-scripts', ['typescript-transpile'], function () {
    gulp.src(paths.scripDist + "/app/modules/" + moduleName + "/**/*.js")
    //.pipe(webpack())
    .pipe(gulp.dest(paths.scriptDestination))
});

gulp.task('lint-typescript', function () {
    gulp.src(['app/**/*.ts'])
        .pipe(tslint())
        .pipe(tslint.report('verbose'));
});

gulp.task('typescript-transpile', ['lint-typescript'], function () {
    var tsResult = tsProject.src()
        .pipe(typescript(tsProject));
    return tsResult.js.pipe(gulp.dest(paths.scripDist + "/app/modules/" + moduleName));
});
gulp.task('watch-blog', function () {
    gulp.watch('app/**/*.ts', ['copy-scripts']);
});
