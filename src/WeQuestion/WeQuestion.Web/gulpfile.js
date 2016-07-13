/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var rename = require('gulp-rename');
var cleanCSS = require('gulp-clean-css');

gulp.task('sass', function () {
    return gulp.src('./Style/**/*.scss')
      .pipe(sass().on('error', sass.logError))
      .pipe(concat('style.css'))
      .pipe(cleanCSS())
      .pipe(gulp.dest('./Content'));
});

gulp.task('sass:watch', function () {
    gulp.watch('./Style/**/*.scss', ['sass']);
});