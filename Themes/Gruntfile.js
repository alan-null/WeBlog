const xpath = require("xpath");
const dom = require("xmldom").DOMParser;

module.exports = function(grunt) {
	
	grunt.loadNpmTasks("grunt-contrib-less");
	grunt.loadNpmTasks("grunt-contrib-copy");
	
	grunt.initConfig({
		pkg: grunt.file.readJSON("package.json"),
		less: {
			dev: {
				files: [{
					expand: true,
					cwd: ".",
					src: ["**/*.less", "!node_modules/**/*.*", "!import_*.less"],
					dest: "build",
					ext: ".css"
				}]
			}
		},
		copy: {
			dev: {
				files: [{
					expand: true,
					cwd: "build",
					src: ["**/*.*"],
					dest: ""
				},
				{
					expand: true,
					cwd: ".",
					src: ["**/*.png", "**/*.gif", "**/*.js", "!node_modules/**/*.*", "!bower_components/**/*.*", "!Gruntfile.js"],
					dest: ""
				},
				{
					expand: true,
					flatten: true,
					cwd: ".",
					src: ["**/jquery/dist/jquery.js", "**/jsurl/url.min.js"],
					dest: "common\\lib"
				}]
			}
		}
	});
	
	var version = grunt.option("scversion") || "sc8.0";
	
	grunt.registerTask("default", ["less", "deploy:" + version]);
	
	grunt.registerTask("deploy", "desc", function(version){
		if(!version){
			grunt.fail.warn("Missing 'version' parameter.");
		}
		
		var targetPath = resolveSitecorePath(version);
		if(!targetPath){
			grunt.fail.warn("Failed to resolve path for version '" + version + "'.");
		}
		
		var fileConfigs = grunt.config.get("copy.dev.files");
		
		fileConfigs.forEach(function(config, index) {
			var path = targetPath + "\\sitecore modules\\Web\\WeBlog\\Themes\\" + config.dest;
			grunt.config.set("copy.dev.files." + index + ".dest", path);
		});
		
		grunt.task.run("copy:dev");
	});
	
	function resolveSitecorePath(version) {
		var file = grunt.file.read("../deploy.targets");
		var doc = new dom().parseFromString(file);

		var select = xpath.useNamespaces({
			"msb": "http://schemas.microsoft.com/developer/msbuild/2003"
		});
		
		var nodes = select("/msb:Project/msb:PropertyGroup[contains(@Condition, '" + version + "')]/msb:SitecorePath/text()", doc);
		
		return nodes[0].toString();
	};
};