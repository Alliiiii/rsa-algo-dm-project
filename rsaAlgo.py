def gcd(a,b):
    while b!=0:
        c=a%b
        a=b
        b=c
    return a 

def D(phi,e):
    d=1
    while ((d*e)%phi) != 1:       
        d=d+1
    return d

def Encript(e,n,x):
    c=[]
    for i in range(len(x)):
        c.append((x[i]**e)%n)
    return c

def Decript(d,n,c):
    p=[]
    for i in range(len(c)):
        k=(c[i]**d)%n
        p.append(k)
    return p
    
def NumberToText(P):
    Decripted=""
    for i in range(len(P)):
        Decripted=Decripted+chr(P[i])
     
    return Decripted

def TextToNumber(s):
    return [ord(c) for c in s]

import random

def randomGenertor():
   
    isPrime = 1
    while True:
        i = random.randint(100,200)
        for j in range(2,i):
            if i != j and i % j == 0:
                isPrime = 0
                break
            

        
        if isPrime==1:
            return i
        
        isPrime = 1


#Text Reader
def TextReader(R):
    with open(R, 'r') as myfile:
        return  myfile.read()




         
p=randomGenertor()
q=randomGenertor()
n=p*q
phi=(p-1)*(q-1)
#e=int(TextReader('Key.txt'))
e=50
while e == p or e == q or e > phi or e < 3 or gcd(e, phi) != 1:
        e=e+1

#s = TextReader('fff.txt')
s="Memory to Memory A single MOV instruction."
     
d=D(phi,e)

#text_key = open("PvtKey", "w", encoding='utf-8')

#text_key.write(str(d))

#text_key.close()  


C=Encript(e,n,TextToNumber(s))
print("\n++++Encripted Text++++")
print(NumberToText(C))
print("Privite Key= ",d)
print("\n++++Decripted Text++++")
P=Decript(d,n,C)
print(NumberToText(P))

#open Decripted File 
#text_file = open("Decript.txt", "w", encoding='utf-8')

#text_file.write(NumberToText(C))

#text_file.close()