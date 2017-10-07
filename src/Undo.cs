using System;
using System.Collections.Generic;
using System.Drawing;
using Substrate;

namespace CreativeModePlus
{
    class Undo
    {
        private static bool init;
        private static Stack<ElemUndo> undoStk,
                                         redoStk;

        private static void initialize()
        {
            undoStk = new Stack<ElemUndo>();
            redoStk = new Stack<ElemUndo>();
            init = true;

        }

        public static String peek()
        {
            String toRet = "";

            if (init && undoStk.Count != 0)
                toRet = undoStk.Peek().name;

            return toRet;

        }

        public static void add(ElemUndo toAdd)
        {
            if (!init)
                initialize();

            if (redoStk.Count > 0)
                redoStk.Clear();

            undoStk.Push(toAdd);

        }

        public static void reAdd(ElemUndo toAdd)
        {
            redoStk.Push(toAdd);

        }

        public static ElemUndo undo()
        {
            ElemUndo toRet = null;

            if (init && undoStk.Count > 0)
            {
                toRet = undoStk.Pop();
                redoStk.Push(toRet);

            }

            return toRet;

        }

        public static ElemUndo redo()
        {
            ElemUndo toRet = null;

            if (init && redoStk.Count > 0)
            {
                toRet = redoStk.Pop();
                undoStk.Push(toRet);

            }

            return toRet;

        }

        public static void clear()
        {
            if (init)
            {
                undoStk.Clear();
                redoStk.Clear();

            }
        }
    }
}
