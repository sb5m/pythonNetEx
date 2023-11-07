from pythonnet import load
load("coreclr")

import clr
clr.AddReference("CholeskyDecomposition")

from CholeskyDecomposition import Program

def main():
    program = Program()
    program.Main([])

if __name__ == "__main__":
    main()
    
    import time
    time.sleep(30)