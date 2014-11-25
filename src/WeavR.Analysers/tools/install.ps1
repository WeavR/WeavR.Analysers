param($installPath, $toolsPath, $package, $project)

$analyzerPath = join-path $toolsPath "analyzers"
$analyzerFilePath = join-path $analyzerPath "WeavR.Analysers.dll"

$project.Object.AnalyzerReferences.Add("$analyzerFilePath")