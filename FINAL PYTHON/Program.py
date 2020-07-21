import bitarray

                    
bitArray = bitarray.bitarray()
raw = []
process1 = []
process2 = []
timeTzone = []
time = []
Milisecnds = []
timezone = []
date = []
i = 0
with open("Input.csv") as file_object:
	raw = file_object.readlines()

for lines in range(len(raw)):
 	  	process1 = raw[lines].split('T')
 	  	process2 = process1[1].split(',')
 	  	timeTzone = process2[0].split('-')
 	  	time = timeTzone[0].split(':')
 	  	Milisecnds = time[2].split('.')
 	  	timezone = timeTzone[1].split(':')
 	  	date = process1[0].split('-')
 	  	year = date[0]
 	  	month = date[1]
 	  	dia = date[2]
 	  	hour = time[0]
 	  	minutes = time[1]
 	  	seconds = Milisecnds[0]
 	  	miliseconds = Milisecnds[1]
 	  	tzhour = timezone[0]
 	  	tzminutes = timezone[1]
 	  	mintemp = process2[1]
 	  	maxtemp = process2[2]
 	  	precipitation = process2[3]
 	  	year = "{0:b}".format(int(year))
 	  	month = "{0:b}".format(int(month))
 	  	dia = "{0:b}".format(int(dia))
 	  	hour = "{0:b}".format(int(hour))
 	  	minutes = "{0:b}".format(int(minutes))
 	  	seconds = "{0:b}".format(int(seconds))
 	  	miliseconds = "{0:b}".format(int(miliseconds))
 	  	tzhour = "{0:b}".format(int(tzhour))
 	  	tzminutes = "{0:b}".format(int(tzminutes))
 	  	mintemp = "{0:b}".format(int(mintemp))
 	  	maxtemp = "{0:b}".format(int(maxtemp))
 	  	precipitation = "{0:b}".format(int(precipitation))
 	  	DateTime = year+month+dia+hour+minutes+seconds+miliseconds+tzhour+tzminutes
 	  	Climate = mintemp+maxtemp+precipitation
 	  	DateTime = int(DateTime, 2)
 	  	Climate = int(Climate, 2)
 	  	alltin = str(DateTime) + "," + str(Climate)
 	  	wr = open("Output.csv", "a")
 	  	for i in range(1):
 	  		wr.write( alltin)
 	  		wr.write("\n")
 	  		wr.close()

 	  	
 
 	  	
  	 
        

