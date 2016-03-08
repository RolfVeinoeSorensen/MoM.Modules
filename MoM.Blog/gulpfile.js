/// <binding AfterBuild='copy-module, copy-scripts' />
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
    rename = require('gulp-rename');

var tsProject = typescript.createProject('app/tsconfig.json');

var paths = {
    modulepath: "../artifacts/bin/MoM.Blog/Debug/dnxcore50/",
    moduleDestination: "../../MoM/artifacts/bin/Modules",
    scripDist: "./wwwroot",
    scriptDestination: "../../MoM/MoM.Web/wwwroot/app/modules/blog"
}

gulp.task('copy-module', function () {
    gulp.src([
                paths.modulepath + "MoM.Blog.dll",
                paths.modulepath + "MoM.Blog.pdb"
    ])
    .pipe(gulp.dest(paths.moduleDestination));
});

gulp.task('copy-scripts', ['typescript-transpile'], function () {
    gulp.src(paths.scripDist + "/app/modules/blog/**/*.js")
    .pipe(gulp.dest(paths.scriptDestination))
});

gulp.task('lint-typescript', function () {
    gulp.src(['app/*.ts', 'app/**/**/*.ts', 'app/**/*.ts'])
        .pipe(tslint())
        .pipe(tslint.report('verbose'));
});

gulp.task('typescript-transpile', ['lint-typescript'], function () {
    var tsResult = tsProject.src()
        .pipe(typescript(tsProject));
    return tsResult.js.pipe(gulp.dest(paths.scripDist + "/app/modules/blog"));
});