
dag2 <- function()
{
  data <- scan("R-code/Input2.txt", 
               what = list(Direction = "", Value = 0),
               sep=" ")
  
  forwards <- 0
  ups <- 0
  downs <- 0
  
  for (i in 1:length(data$Direction)) {
    if (data$Direction[i] == 'forward') { forwards <- forwards + data$Value[i] }
    else if (data$Direction[i] == 'up') { ups <- ups + data$Value[i] }
    else {downs <- downs + data$Value[i]}
  }
  
  return(forwards * (downs - ups))
}

dag2b <- function()
{
  data <- scan("R-code/Input2.txt", 
               what = list(Direction = "", Value = 0),
               sep=" ")
  
  forwards <- 0
  depth <- 0
  aim <- 0 
  
  for (i in 1:length(data$Direction)) {
    if (data$Direction[i] == 'forward') 
    { 
      forwards <- forwards + data$Value[i] 
      depth <- depth + aim * data$Value[i]
    }
    else if (data$Direction[i] == 'up') 
    { 
      aim <- aim - data$Value[i]
    }
    else 
    {
      aim <- aim + data$Value[i]
    }
  }
  
  return(forwards * depth)
}

