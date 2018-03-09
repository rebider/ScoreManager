module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),
	concat:{
		options: {
		   separator: ';'
		},
		dist:{
		    cwd: 'Scripts',
			src:'**/*.js',
			dest: 'Scripts/dist/concat.js'
		}
	},
    uglify: {
      options: {
        banner: '/*! mal <%= grunt.template.today("yyyy-mm-dd") %> */\n',
		mangle: true
      },
      uglify: {
		options:{
			compress:{
				global_defs: {
					'DEBUG': false
				},
				dead_code: true,
				drop_console:true
			},
			report:"min"
		},
		files:[{
			expand:true,
			cwd: 'Scripts',
			src:'**/*.js',
			dest: 'Scripts/dist/'
		}]       
      }
    }
  });

  // 加载包含 "uglify" 任务的插件。
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-concat');
  // 默认被执行的任务列表。
  grunt.registerTask('all',['uglify','concat']);
  grunt.registerTask('ug', ['uglify']);
};