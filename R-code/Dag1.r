
dag1 <- function()
{
  f<-scan(file = "R-code/Input1.txt", what = integer())
  
  increments <- 0
  
  for (i in 2:length(f))
  {
    previous <- f[i - 1]
    current <- f[i]
    if (current > previous)
    {
      increments <- increments + 1
    }
  }
  
  return(increments)
}

dag1b <- function()
{
  f<-scan(file = "R-code/Input1.txt", what = integer())
  
  increments <- 0
  
  for (i in 1:(length(f) - 3))
  {
    firstSum <- f[i] + f[i+1] + f[i+2]
    secondSum <- f[i+1] + f[i+2] + f[i+3]
    
    if (secondSum > firstSum)
    {
      increments <- increments + 1
    }
  }
  
  return(increments)
}

